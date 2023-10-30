#include <algorithm>
#include <chrono>
#include <cassert>
#include <iostream>
#include <random>
#include <thread>
#include <vector>

// Partition the array around a pivot, returning the index of the pivot
int partition(std::vector<int>& arr, int low, int high) {
	// Check that the indices are within bounds
	if (low < 0 || low >= arr.size() || high < 0 || high >= arr.size()) {
		return -1;
	}

	// Select the median of the first, middle, and last elements as the pivot
	int mid = low + (high - low) / 2;
	if (arr[mid] > arr[high]) std::swap(arr[mid], arr[high]);
	if (arr[low] > arr[high]) std::swap(arr[low], arr[high]);
	if (arr[mid] > arr[low]) std::swap(arr[mid], arr[low]);
	int pivot = arr[low];

	int i = low;
	for (int j = low + 1; j <= high; j++) {
		if (arr[j] <= pivot) {
			i++;
			std::swap(arr[i], arr[j]);
		}
	}
	std::swap(arr[i], arr[low]);
	return i;
}


// Perform an insertion sort on the given range of the array
void insertion_sort(std::vector<int>& arr, int low, int high) {
	for (int i = low + 1; i <= high; i++) {
		int j = i;
		while (j > low && arr[j - 1] > arr[j]) {
			std::swap(arr[j - 1], arr[j]);
			j--;
		}
	}
}

// Recursive function for introsort
void introsort_recursive(std::vector<int>& arr, int low, int high, int depthLimit) {
	// Perform an insertion sort on small arrays to improve performance
	if (low >= high) return;
	if (depthLimit == 0) {
		insertion_sort(arr, low, high);
		return;
	}

	// Partition the array and recursively sort the two halves
	int pivotIndex = partition(arr, low, high);
	std::thread leftThread;
	if (pivotIndex - 1 > low) {
		// Sort the left half in a separate thread
		leftThread = std::thread(introsort_recursive, std::ref(arr), low, pivotIndex - 1, depthLimit - 1);
		leftThread.detach();
	}
	else {
		// Sort the right half in the current thread
		introsort_recursive(arr, pivotIndex + 1, high, depthLimit - 1);
	}

	// Wait for the left half to finish sorting
	if (pivotIndex - 1 > low) {
		while (leftThread.joinable()) {
			leftThread.join();
		}
	}
}



// Quicksort the array using the introsort hybrid sorting algorithm
void introsort(std::vector<int>& arr, int low, int high) {
	int depthLimit = 2 * log(high - low + 1);
	introsort_recursive(arr, low, high, depthLimit);
}

int main() {
	const int N = pow(10, 8);
	std::vector<int> arr;

	// Generate N random numbers
	std::random_device rd;
	std::mt19937 gen(rd());
	std::uniform_int_distribution<> dis(1, N);
	for (int i = 0; i < N; i++) {
		arr.push_back(dis(gen));
	}

	// Record the start time
	auto start = std::chrono::high_resolution_clock::now();

	// Sort the array using introsort
	introsort(arr, 0, arr.size() - 1);

	// Record the end time
	auto end = std::chrono::high_resolution_clock::now();

	// Calculate the elapsed time
	std::chrono::duration<double> elapsed = end - start;
	std::cout << "Elapsed time: " << elapsed.count() << " seconds" << std::endl;

	// Check that the array is now sorted in ascending order
	for (int i = 1; i < arr.size(); i++) {
		assert(arr[i] >= arr[i - 1]);
	}
	std::cout << "Test passed!" << std::endl;
	return 0;
}
